// Generated from /Users/stephen/Projects/lolc/src/Antlr/LolCode.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class LolCodeParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, NUMBAR=15, NUMBR=16, 
		YARN=17, STRING=18, FLOAT=19, INT=20, O=21, HAI=22, KTHXBYE=23, I_HAZ_A=24, 
		ITZ=25, LOL=26, R=27, I_SEZ=28, BANG=29, IZ=30, ID=31, WS=32;
	public static final int
		RULE_program = 0, RULE_programStart = 1, RULE_programEnd = 2, RULE_statement = 3, 
		RULE_assignment = 4, RULE_varDecl = 5, RULE_print = 6, RULE_if_stat = 7, 
		RULE_if_true_clause = 8, RULE_if_false_clause = 9, RULE_lolType = 10, 
		RULE_expression = 11, RULE_atom = 12, RULE_op = 13;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "programStart", "programEnd", "statement", "assignment", "varDecl", 
			"print", "if_stat", "if_true_clause", "if_false_clause", "lolType", "expression", 
			"atom", "op"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'?'", "'KTHX'", "'YARLY!'", "'NOWAI!'", "'('", "')'", "'WIF'", 
			"'UP'", "'NERF'", "'TIEMZ'", "'OVAR'", "'BIGR THAN'", "'SMALR THAN'", 
			"'LIEK'", "'NUMBAR'", "'NUMBR'", "'YARN'", null, null, null, "'O'", "'HAI'", 
			"'KTHXBYE'", "'I HAZ A'", "'ITZ'", "'LOL'", "'R'", "'I SEZ'", "'!'", 
			"'IZ'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, "NUMBAR", "NUMBR", "YARN", "STRING", "FLOAT", "INT", 
			"O", "HAI", "KTHXBYE", "I_HAZ_A", "ITZ", "LOL", "R", "I_SEZ", "BANG", 
			"IZ", "ID", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "LolCode.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public LolCodeParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public StatementContext statement;
		public List<StatementContext> stats = new ArrayList<StatementContext>();
		public ProgramStartContext programStart() {
			return getRuleContext(ProgramStartContext.class,0);
		}
		public ProgramEndContext programEnd() {
			return getRuleContext(ProgramEndContext.class,0);
		}
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(28);
			programStart();
			setState(30); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(29);
				((ProgramContext)_localctx).statement = statement();
				((ProgramContext)_localctx).stats.add(((ProgramContext)_localctx).statement);
				}
				}
				setState(32); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << I_HAZ_A) | (1L << LOL) | (1L << I_SEZ) | (1L << IZ))) != 0) );
			setState(35);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==KTHXBYE) {
				{
				setState(34);
				programEnd();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ProgramStartContext extends ParserRuleContext {
		public TerminalNode HAI() { return getToken(LolCodeParser.HAI, 0); }
		public TerminalNode O() { return getToken(LolCodeParser.O, 0); }
		public ProgramStartContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_programStart; }
	}

	public final ProgramStartContext programStart() throws RecognitionException {
		ProgramStartContext _localctx = new ProgramStartContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_programStart);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(38);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==O) {
				{
				setState(37);
				match(O);
				}
			}

			setState(40);
			match(HAI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ProgramEndContext extends ParserRuleContext {
		public TerminalNode KTHXBYE() { return getToken(LolCodeParser.KTHXBYE, 0); }
		public ProgramEndContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_programEnd; }
	}

	public final ProgramEndContext programEnd() throws RecognitionException {
		ProgramEndContext _localctx = new ProgramEndContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_programEnd);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(42);
			match(KTHXBYE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public VarDeclContext varDecl() {
			return getRuleContext(VarDeclContext.class,0);
		}
		public PrintContext print() {
			return getRuleContext(PrintContext.class,0);
		}
		public If_statContext if_stat() {
			return getRuleContext(If_statContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_statement);
		try {
			setState(48);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case LOL:
				enterOuterAlt(_localctx, 1);
				{
				setState(44);
				assignment();
				}
				break;
			case I_HAZ_A:
				enterOuterAlt(_localctx, 2);
				{
				setState(45);
				varDecl();
				}
				break;
			case I_SEZ:
				enterOuterAlt(_localctx, 3);
				{
				setState(46);
				print();
				}
				break;
			case IZ:
				enterOuterAlt(_localctx, 4);
				{
				setState(47);
				if_stat();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode LOL() { return getToken(LolCodeParser.LOL, 0); }
		public TerminalNode ID() { return getToken(LolCodeParser.ID, 0); }
		public TerminalNode R() { return getToken(LolCodeParser.R, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(50);
			match(LOL);
			setState(51);
			match(ID);
			setState(52);
			match(R);
			setState(53);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VarDeclContext extends ParserRuleContext {
		public TerminalNode I_HAZ_A() { return getToken(LolCodeParser.I_HAZ_A, 0); }
		public LolTypeContext lolType() {
			return getRuleContext(LolTypeContext.class,0);
		}
		public TerminalNode ITZ() { return getToken(LolCodeParser.ITZ, 0); }
		public TerminalNode ID() { return getToken(LolCodeParser.ID, 0); }
		public VarDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varDecl; }
	}

	public final VarDeclContext varDecl() throws RecognitionException {
		VarDeclContext _localctx = new VarDeclContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_varDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(55);
			match(I_HAZ_A);
			setState(56);
			lolType();
			setState(57);
			match(ITZ);
			setState(58);
			match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PrintContext extends ParserRuleContext {
		public ExpressionContext expr;
		public TerminalNode I_SEZ() { return getToken(LolCodeParser.I_SEZ, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode BANG() { return getToken(LolCodeParser.BANG, 0); }
		public PrintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_print; }
	}

	public final PrintContext print() throws RecognitionException {
		PrintContext _localctx = new PrintContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_print);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(60);
			match(I_SEZ);
			setState(61);
			((PrintContext)_localctx).expr = expression(0);
			setState(63);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==BANG) {
				{
				setState(62);
				match(BANG);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class If_statContext extends ParserRuleContext {
		public ExpressionContext expr;
		public TerminalNode IZ() { return getToken(LolCodeParser.IZ, 0); }
		public If_true_clauseContext if_true_clause() {
			return getRuleContext(If_true_clauseContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public If_false_clauseContext if_false_clause() {
			return getRuleContext(If_false_clauseContext.class,0);
		}
		public If_statContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_if_stat; }
	}

	public final If_statContext if_stat() throws RecognitionException {
		If_statContext _localctx = new If_statContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_if_stat);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(65);
			match(IZ);
			setState(66);
			((If_statContext)_localctx).expr = expression(0);
			setState(67);
			match(T__0);
			setState(68);
			if_true_clause();
			setState(70);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(69);
				if_false_clause();
				}
			}

			setState(72);
			match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class If_true_clauseContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public If_true_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_if_true_clause; }
	}

	public final If_true_clauseContext if_true_clause() throws RecognitionException {
		If_true_clauseContext _localctx = new If_true_clauseContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_if_true_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(74);
			match(T__2);
			setState(78);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << I_HAZ_A) | (1L << LOL) | (1L << I_SEZ) | (1L << IZ))) != 0)) {
				{
				{
				setState(75);
				statement();
				}
				}
				setState(80);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class If_false_clauseContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public If_false_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_if_false_clause; }
	}

	public final If_false_clauseContext if_false_clause() throws RecognitionException {
		If_false_clauseContext _localctx = new If_false_clauseContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_if_false_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(81);
			match(T__3);
			setState(85);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << I_HAZ_A) | (1L << LOL) | (1L << I_SEZ) | (1L << IZ))) != 0)) {
				{
				{
				setState(82);
				statement();
				}
				}
				setState(87);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LolTypeContext extends ParserRuleContext {
		public TerminalNode NUMBAR() { return getToken(LolCodeParser.NUMBAR, 0); }
		public TerminalNode NUMBR() { return getToken(LolCodeParser.NUMBR, 0); }
		public TerminalNode YARN() { return getToken(LolCodeParser.YARN, 0); }
		public LolTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_lolType; }
	}

	public final LolTypeContext lolType() throws RecognitionException {
		LolTypeContext _localctx = new LolTypeContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_lolType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(88);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NUMBAR) | (1L << NUMBR) | (1L << YARN))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext expr;
		public AtomContext atom() {
			return getRuleContext(AtomContext.class,0);
		}
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public OpContext op() {
			return getRuleContext(OpContext.class,0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 22;
		enterRecursionRule(_localctx, 22, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case STRING:
			case FLOAT:
			case INT:
			case ID:
				{
				setState(91);
				atom();
				}
				break;
			case T__4:
				{
				setState(92);
				match(T__4);
				setState(93);
				((ExpressionContext)_localctx).expr = expression(0);
				setState(94);
				match(T__5);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(104);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExpressionContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expression);
					setState(98);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(99);
					op();
					setState(100);
					expression(3);
					}
					} 
				}
				setState(106);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class AtomContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(LolCodeParser.STRING, 0); }
		public TerminalNode INT() { return getToken(LolCodeParser.INT, 0); }
		public TerminalNode FLOAT() { return getToken(LolCodeParser.FLOAT, 0); }
		public TerminalNode ID() { return getToken(LolCodeParser.ID, 0); }
		public AtomContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_atom; }
	}

	public final AtomContext atom() throws RecognitionException {
		AtomContext _localctx = new AtomContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_atom);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << ID))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OpContext extends ParserRuleContext {
		public OpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_op; }
	}

	public final OpContext op() throws RecognitionException {
		OpContext _localctx = new OpContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_op);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__6) | (1L << T__7) | (1L << T__8) | (1L << T__9) | (1L << T__10) | (1L << T__11) | (1L << T__12) | (1L << T__13))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 11:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\"r\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t\13\4"+
		"\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\3\2\3\2\6\2!\n\2\r\2\16\2\"\3\2\5\2"+
		"&\n\2\3\3\5\3)\n\3\3\3\3\3\3\4\3\4\3\5\3\5\3\5\3\5\5\5\63\n\5\3\6\3\6"+
		"\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\5\bB\n\b\3\t\3\t\3\t\3\t"+
		"\3\t\5\tI\n\t\3\t\3\t\3\n\3\n\7\nO\n\n\f\n\16\nR\13\n\3\13\3\13\7\13V"+
		"\n\13\f\13\16\13Y\13\13\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\5\rc\n\r\3\r\3"+
		"\r\3\r\3\r\7\ri\n\r\f\r\16\rl\13\r\3\16\3\16\3\17\3\17\3\17\2\3\30\20"+
		"\2\4\6\b\n\f\16\20\22\24\26\30\32\34\2\5\3\2\21\23\4\2\24\26!!\3\2\t\20"+
		"\2o\2\36\3\2\2\2\4(\3\2\2\2\6,\3\2\2\2\b\62\3\2\2\2\n\64\3\2\2\2\f9\3"+
		"\2\2\2\16>\3\2\2\2\20C\3\2\2\2\22L\3\2\2\2\24S\3\2\2\2\26Z\3\2\2\2\30"+
		"b\3\2\2\2\32m\3\2\2\2\34o\3\2\2\2\36 \5\4\3\2\37!\5\b\5\2 \37\3\2\2\2"+
		"!\"\3\2\2\2\" \3\2\2\2\"#\3\2\2\2#%\3\2\2\2$&\5\6\4\2%$\3\2\2\2%&\3\2"+
		"\2\2&\3\3\2\2\2\')\7\27\2\2(\'\3\2\2\2()\3\2\2\2)*\3\2\2\2*+\7\30\2\2"+
		"+\5\3\2\2\2,-\7\31\2\2-\7\3\2\2\2.\63\5\n\6\2/\63\5\f\7\2\60\63\5\16\b"+
		"\2\61\63\5\20\t\2\62.\3\2\2\2\62/\3\2\2\2\62\60\3\2\2\2\62\61\3\2\2\2"+
		"\63\t\3\2\2\2\64\65\7\34\2\2\65\66\7!\2\2\66\67\7\35\2\2\678\5\30\r\2"+
		"8\13\3\2\2\29:\7\32\2\2:;\5\26\f\2;<\7\33\2\2<=\7!\2\2=\r\3\2\2\2>?\7"+
		"\36\2\2?A\5\30\r\2@B\7\37\2\2A@\3\2\2\2AB\3\2\2\2B\17\3\2\2\2CD\7 \2\2"+
		"DE\5\30\r\2EF\7\3\2\2FH\5\22\n\2GI\5\24\13\2HG\3\2\2\2HI\3\2\2\2IJ\3\2"+
		"\2\2JK\7\4\2\2K\21\3\2\2\2LP\7\5\2\2MO\5\b\5\2NM\3\2\2\2OR\3\2\2\2PN\3"+
		"\2\2\2PQ\3\2\2\2Q\23\3\2\2\2RP\3\2\2\2SW\7\6\2\2TV\5\b\5\2UT\3\2\2\2V"+
		"Y\3\2\2\2WU\3\2\2\2WX\3\2\2\2X\25\3\2\2\2YW\3\2\2\2Z[\t\2\2\2[\27\3\2"+
		"\2\2\\]\b\r\1\2]c\5\32\16\2^_\7\7\2\2_`\5\30\r\2`a\7\b\2\2ac\3\2\2\2b"+
		"\\\3\2\2\2b^\3\2\2\2cj\3\2\2\2de\f\4\2\2ef\5\34\17\2fg\5\30\r\5gi\3\2"+
		"\2\2hd\3\2\2\2il\3\2\2\2jh\3\2\2\2jk\3\2\2\2k\31\3\2\2\2lj\3\2\2\2mn\t"+
		"\3\2\2n\33\3\2\2\2op\t\4\2\2p\35\3\2\2\2\f\"%(\62AHPWbj";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}